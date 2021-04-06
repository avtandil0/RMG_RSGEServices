using NtosService;
using RSGEServices.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RSGEServices.BLL.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<GenericResult<get_buyer_invoices_rResponseGet_buyer_invoices_rResult>> Get_buyer_invoices_rAsync(
            int user_id, int un_id, int status, string su, string sp);

        /// <summary>
        /// ანგარიშ-ფაქტურების ნახვა
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="un_id"></param>
        /// <param name="s_dt"></param>
        /// <param name="e_dt"></param>
        /// <param name="op_s_dt"></param>
        /// <param name="op_e_dt"></param>
        /// <param name="invoice_no"></param>
        /// <param name="sa_ident_no"></param>
        /// <param name="desc"></param>
        /// <param name="doc_mos_nom"></param>
        /// <param name="su"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        Task<GenericResult<get_buyer_invoicesResponseGet_buyer_invoicesResult>> Get_buyer_invoicesAsync( int user_id, int un_id, 
            DateTime s_dt, DateTime e_dt,DateTime op_s_dt, DateTime op_e_dt, string invoice_no, string sa_ident_no,
            string desc, string doc_mos_nom, string su, string sp);

        /// <summary>
        /// ანგარიშ ფაქტურის საქონლის მონაცემების ნახვა
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="un_id"></param>
        /// <param name="s_dt"></param>
        /// <param name="e_dt"></param>
        /// <param name="op_s_dt"></param>
        /// <param name="op_e_dt"></param>
        /// <param name="invoice_no"></param>
        /// <param name="sa_ident_no"></param>
        /// <param name="desc"></param>
        /// <param name="doc_mos_nom"></param>
        /// <param name="su"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        Task<GenericResult<get_invoice_descResponseGet_invoice_descResult>> Get_invoice_descAsync(int user_id,
            int invois_id, string su, string sp);

        Task<GenericResult<get_tin_from_un_idResponse>> Get_tin_from_un_id(int user_id,
           int invois_id, string su, string sp);

        Task<GenericResult<get_ser_usersResponse>> Get_ser_users( string su, string sp);
        Task<GenericResult<get_un_id_from_tinResponse>> Get_un_id_from_tin(int user_id, string tin, string su, string sp);
        Task<GenericResult<int>> get_un_id_from_user_idAsync(int user_id,  string su, string sp);

    }
}
