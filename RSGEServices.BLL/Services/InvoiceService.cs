using NtosService;
using RSGEServices.BLL.Models;
using RSGEServices.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSGEServices.BLL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private NtosServiceSoapClient Services = new NtosServiceSoapClient(NtosServiceSoapClient.EndpointConfiguration.NtosServiceSoap12);

        public async Task<GenericResult<get_buyer_invoicesResponseGet_buyer_invoicesResult>> Get_buyer_invoicesAsync(int user_id, int un_id, DateTime s_dt, DateTime e_dt, DateTime op_s_dt, DateTime op_e_dt, string invoice_no, string sa_ident_no, string desc, string doc_mos_nom, string su, string sp)
        {
            var result = await Services.get_buyer_invoicesAsync(user_id, un_id, s_dt, e_dt, op_s_dt, op_e_dt, invoice_no, sa_ident_no, desc, doc_mos_nom, su, sp);

            return new GenericResult<get_buyer_invoicesResponseGet_buyer_invoicesResult>
                (true, 1, null, result);

        }

        public async Task<GenericResult<get_ser_usersResponse>>
                Get_ser_users(string su, string sp)
        {
            var user = new get_ser_usersRequest(su, sp);
            var result = await Services.get_ser_usersAsync(user);

            return new GenericResult<get_ser_usersResponse>
                (true, 1, null, result);

        }

        public async Task<GenericResult<get_buyer_invoices_rResponseGet_buyer_invoices_rResult>> 
            Get_buyer_invoices_rAsync(int user_id, int un_id, int status, string su, string sp)
        {
            var result = await Services.get_buyer_invoices_rAsync(user_id, un_id, status, su, sp);

            //if (result.Any1.IsEmpty)
            //{
            //    return new GenericResult(false, -1, "Data is Empty", null); 
            //}
            return new GenericResult<get_buyer_invoices_rResponseGet_buyer_invoices_rResult>
                (true,1, null,result);
        }

        public async Task<GenericResult<get_invoice_descResponseGet_invoice_descResult>> Get_invoice_descAsync(
            int user_id, int invois_id, string su, string sp)
        {
            var result = await Services.get_invoice_descAsync(user_id, invois_id,su, sp);


            return new GenericResult<get_invoice_descResponseGet_invoice_descResult>
                (true, 1, null, result);
        }

        public async Task<GenericResult<get_tin_from_un_idResponse>> Get_tin_from_un_id(int user_id, int un_id, string su, string sp)
        {
            get_tin_from_un_idRequest user = new get_tin_from_un_idRequest(user_id, un_id, su, sp);
            var result = await Services.get_tin_from_un_idAsync(user);


            return new GenericResult<get_tin_from_un_idResponse>
                (true, 1, null, result);
        }

        public async Task<GenericResult<int>> get_un_id_from_user_idAsync(int user_id,
                string su, string sp)
        {
            var result = await Services.get_un_id_from_user_idAsync(user_id, su, sp);


            return new GenericResult<int>
                (true, 1, null, result);
        }

        public async Task<GenericResult<get_un_id_from_tinResponse>> Get_un_id_from_tin(int user_id, string tin,
                string su, string sp)
        {
            var requestObject = new get_un_id_from_tinRequest
            {
                sp = sp,
                su = su,
                tin = tin,
                user_id = user_id
            };

            var result = await Services.get_un_id_from_tinAsync(requestObject);


            return new GenericResult<get_un_id_from_tinResponse>
                (true, 1, null, result);
        }
    }
}
