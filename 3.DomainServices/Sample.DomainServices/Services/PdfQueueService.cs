using Sample.DomainServices.Core;
using Sample.EntityModels.Queues;
using Sample.IDomainServices;
using Sample.IDomainServices.AutoMapper;
using Sample.IDomainServices.Queues;
using Sample.InfraStructure.Logging;
using Sample.IRepositories.Identity;
using Sample.IRepositories.Queues;
using Sample.Utility;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sample.DomainServices
{
    public class PdfQueueService : BaseService<PdfQueueEntityModel, PdfQueueViewModel>, IPdfQueueService
    {

        public List<PdfQueueViewModel> GetPendingPdfQueue()
        {
            var result = new List<PdfQueueViewModel>();

            var entityList = UnitOfWork.PdfQueueRepository.GetPendingPdfQueue().ToList();

            if (entityList != null && entityList.Count > 0)
            {
                result = entityList.ToViewModel<PdfQueueEntityModel, PdfQueueViewModel>().ToList();
            }

            return result;
        }

        public bool ProcessPendingPdfs()
        {
            var pendingpdfs = GetPendingPdfQueue();
            var result = false;
            foreach (PdfQueueViewModel pdfQueueViewModel in pendingpdfs)
            {
                try
                {
                    if (!string.IsNullOrEmpty(pdfQueueViewModel.GeneratedHtml))
                    {
                        GeneratePdf(pdfQueueViewModel);
                        UpdatePdfQueue(pdfQueueViewModel, true);
                    }
                    result = true;
                }
                catch (ApplicationException ex)
                {
                    pdfQueueViewModel.ErrorMessage = ex.Message;
                    UpdatePdfQueue(pdfQueueViewModel, false);
                }
            }

            return result;
        }

        private void GeneratePdf(PdfQueueViewModel pdfQueueViewModel)
        {
            try
            {
                var outPutFileName = pdfQueueViewModel.CriminalId.ToString() + ".pdf";

                if (File.Exists(AppProperties.BasePhysicalPath + AppConstants.GenerateFileAt + outPutFileName))
                  {
                    File.Delete(AppProperties.BasePhysicalPath + AppConstants.GenerateFileAt + outPutFileName);
                  }

                 AppMethods.HtmlStringToPdfFile(pdfOutputLocation: AppConstants.GenerateFileAt, outputFilename: outPutFileName,
                                htmlData: pdfQueueViewModel.GeneratedHtml, pdfHtmlToPdfExePath: AppConstants.PdfConvertorPath);
            }
            catch (ApplicationException ex)
            {
                NLogLogger.Instance.Log(ex);
            }
        }

        private void UpdatePdfQueue(PdfQueueViewModel pdfQueueViewModel, bool isSucceed)
        {
            var pdfQueueEntity = UnitOfWork.PdfQueueRepository.FindById(pdfQueueViewModel.Id);
            pdfQueueEntity.IsPdfGenerationSucceed = isSucceed;
            pdfQueueEntity.ReGenerationRequired = !isSucceed;
            UnitOfWork.PdfQueueRepository.Update(pdfQueueEntity);
        }
    }
}
