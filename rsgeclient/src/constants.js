const NO_TABLE_DATA_TEXT = 'მონაცემები ვერ მოიძებნა'
const ROWS_PER_PAGE_TEXT = 'თითო გვერდზე:'

const API_PREFIX = 'https://localhost:44342'


const GEO_MONTH_NAMES = 'იანვარი_თებერვალი_მარტი_აპრილი_მაისი_ივნისი_ივლისი_აგვისტო_სექტემბერი_ოქტომბერი_ნოემბერი_დეკემბერი'.split('_')

const GEO_MONTH_SHORT_NAMES = 'იან_თებ_მარ_აპრ_მაის_ივნ_ივლ_აგვ_სექ_ოქტ_ნოე_დეკ'.split('_')

const GEO_SHORT_WEEKDAYS = 'კვი_ორშ_სამ_ოთხ_ხუთ_პარ_შაბ'.split('_')

const ENG_WEEKDAYS = 'Sunday_Monday_Tuesday_Wednesday_Thursday_Friday_Saturday'.split('_')

const ENG_SHORT_WEEKDAYS = 'S_M_T_W_T_F_S'.split('_')

const GEO_INTL_MONTHS = 'M01_M02_M03_M04_M05_M06_M07_M08_M09_M10_M11_M12'.split('_')

const GEO_INTL_TO_GEO_SHORT_MONTHS = GEO_MONTH_SHORT_NAMES.reduce(
    (acc, geoShortMonth, index) => ({
        ...acc,
        [GEO_INTL_MONTHS[index]]: geoShortMonth,
    }),
    {},
)

const GEO_INTL_TO_GEO_MONTHS = GEO_MONTH_NAMES.reduce(
    (acc, geoMonth, index) => ({
        ...acc,
        [GEO_INTL_MONTHS[index]]: geoMonth,
    }),
    {},
)

const INVOICE_STATUSES = [
    { text: "ახალი", value: 0 },
    { text: "გადაგზავნილი, დასადასტურებელი", value: 1 },
    { text: "დადასტურებული", value: 2 },
    { text: "კორექტირებული", value: 3 },
    { text: "ახალი კორექტირების", value: 4 },
    { text: "კორექტირების გადაგზავნილი, დასადასტურებელი", value: 5 },
    { text: "გაუქმებული", value: 6 },
    { text: "დადასტურებული გაუქმებული", value: 7 },
    { text: "დადასტურებული კორექტირების", value: 8 },
]

export default {
    INVOICE_STATUSES,
    NO_TABLE_DATA_TEXT,
    ROWS_PER_PAGE_TEXT,
    GEO_MONTH_NAMES,
    GEO_MONTH_SHORT_NAMES,
    GEO_SHORT_WEEKDAYS,
    ENG_WEEKDAYS,
    ENG_SHORT_WEEKDAYS,
    GEO_INTL_MONTHS,
    GEO_INTL_TO_GEO_SHORT_MONTHS,
    GEO_INTL_TO_GEO_MONTHS,
    // eslint-disable-next-line no-undef
    API_PREFIX
}