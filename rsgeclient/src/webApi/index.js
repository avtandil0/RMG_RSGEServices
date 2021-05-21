import callApi from './callApi'
// import qs from 'qs'

const postTransaction = (object) => callApi({
    url: '/api/rsgeservices/transaction',
    method: 'post',
    data: { ...object }
})

const getRoles = () => callApi({
    url: '/api/references/claims',
    method: 'get'
})


const getBuyerInvoicesR = () => callApi({
    url: '/api/rsgeservices/getBuyerInvoicesR',
    method: 'get'
})

const getBuyerInvoices = (searchForm) => callApi({
    url: '/api/rsgeservices/getBuyerInvoices',
    method: 'get',
    params: { ...searchForm}
})

const getInvoiceDesc = (id) => callApi({
    url: `/api/rsgeservices/getInvoiceDesc/${id}`,
    method: 'get',
})

const getDagbk = () => callApi({
    url: `/api/dagbk/getDagbk`,
    method: 'get',
})

const getGrtbk = () => callApi({
    url: `/api/grtbk/getGrtbk`,
    method: 'get',
})

const getTin = () => callApi({
    url: `/api/rsgeservices/getTin`,
    method: 'get',
})

const getKstpl = () => callApi({
    url: `/api/references/getKstpl`,
    method: 'get',
})
const getPrproject = () => callApi({
    url: `/api/references/getPrproject`,
    method: 'get',
})
const getKstdr = () => callApi({
    url: `/api/references/getKstdr`,
    method: 'get',
})

const get_ser_users = () => callApi({
    url: `/api/rSGEServices/Get_ser_users`,
    method: 'get',
})

const get_un_id_from_tin = () => callApi({
    url: `/api/rSGEServices/Get_un_id_from_tin`,
    method: 'get',
})

const get_un_id_from_user_id = () => callApi({
    url: `/api/rSGEServices/get_un_id_from_user_id`,
    method: 'get',
})

const getGbkmut = () => callApi({
    url: `/api/references/getGbkmut`,
    method: 'get',
})

const getRsgeinvoiceLog = () => callApi({
    url: `/api/references/getRsgeinvoiceLog`,
    method: 'get',
})

export default {
    getRsgeinvoiceLog,
    getGbkmut,
    get_un_id_from_user_id,
    get_un_id_from_tin,
    get_ser_users,
    postTransaction,
    getKstdr,
    getPrproject,
    getKstpl,
    getTin,
    getGrtbk,
    getDagbk,
    getInvoiceDesc,
    getBuyerInvoices,
    getBuyerInvoicesR,
    getRoles,
}