using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PyConsumerApp
{
    public interface IFCMDetails
    {
        Task<string> GetAppToken();


    }
}
