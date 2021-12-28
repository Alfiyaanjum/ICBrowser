using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;


namespace ICBrowser.Business
{
    public class AdminStaticData
    {
        public void UpdateAboutUs(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateAboutUs(ed);

        }

        public void UpdateEscroSecurity(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateEscrow(ed);

        }

        public void UpdateServicesOffered(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateServicesOffered(ed);

        }

        public void UpdateContactUs(ContactUs cu)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateContactUs(cu);

        }



        public void UpdateStaticImageAu(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateImagepathAu(ed);
        }

        public void UpdateStaticImageEs(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateImagepathEs(ed);
        }

        public void UpdateStaticImageSo(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateImagepathSo(ed);
        }

        public void UpdateStaticImageCu(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateImagepathCu(ed);
        }



        public EscrowDetails GetStaicEscrowData()
        {

            StaticDataRepository escrowdata = new StaticDataRepository();
            EscrowDetails esc = new EscrowDetails();
            try
            {
                esc = escrowdata.GetEscrowStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }
        public WhyUs GetWhyUsData()
        {

            StaticDataRepository escrowdata = new StaticDataRepository();
            WhyUs esc = new WhyUs();
            try
            {
                esc = escrowdata.GetWhyUsStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }
        public PrivatePolicy GetPrivatePolicy()
        {

            StaticDataRepository policydata = new StaticDataRepository();
            PrivatePolicy policy = new PrivatePolicy();
            try
            {
                policy = policydata.GetPrivatePolicyDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return policy;

        }
        public EscrowDetails GetStaticAboutUsData()
        {

            StaticDataRepository aboutusdata = new StaticDataRepository();
            EscrowDetails esc = new EscrowDetails();
            try
            {
                esc = aboutusdata.GetAboutUsStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }

        public EscrowDetails GetStaicServiceData()
        {

            StaticDataRepository servicedata = new StaticDataRepository();
            EscrowDetails esc = new EscrowDetails();
            try
            {
                esc = servicedata.GetServiceStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }

        public ContactUs GetStaticContactUsData()
        {
            StaticDataRepository sdr = new StaticDataRepository();
            ContactUs esc = new ContactUs();
            try
            {
                esc = sdr.GetContactUsStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }

        public EscrowDetails GetStaticLegalAgreementData()
        {

            StaticDataRepository sdr = new StaticDataRepository();
            EscrowDetails esc = new EscrowDetails();
            try
            {
                esc = sdr.GetLegalAgreementStaticDetails();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return esc;

        }



        //FAQ.aspx Data
        public FAQ GetFaqbyQueId(int QueId)
        {
            FAQ faq = new FAQ();
            StaticDataRepository sdr = new StaticDataRepository();
            faq = sdr.GetFaqbyQueId(QueId);
            return faq;
        }

        public List<FAQ> GetFaqData()
        {
            List<FAQ> faq = new List<FAQ>();
            StaticDataRepository dataRepo = new StaticDataRepository();
            faq = dataRepo.GetFaqData();
            return faq;
        }

        public void UpdateEngFaq(FAQ faq)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateFaqEngbyQuestionId(faq);
        }

        public void UpdateCnyFaq(FAQ faq)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateFaqCnybyQuestionId(faq);
        }

        public void AddNewFaq(FAQ faq)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.AddNewFaq(faq);
        }

        public void DeleteFaq(int queId)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.DeleteFaqByQuestionId(queId);
        }


        /// <summary>
        /// Lagal Agreement Page Methods.
        /// </summary>
        public void UpdateLegalAgreementData(EscrowDetails ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateLegalAgreementData(ed);
        }
        public void UpdateWhyUsData(WhyUs ed)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdateWhyusData(ed);
        }
        public void UpdatePrivetPolicy(PrivatePolicy policy)
        {
            StaticDataRepository sdr = new StaticDataRepository();
            sdr.UpdatePrivatepolicyData(policy);
        }

        public void InserUserLocationDetails(UserLocationDetails obj)
        {
            StaticDataRepository data = new StaticDataRepository();
            data.InsertUserLocationDetails(obj);
        }
            
    }
}
