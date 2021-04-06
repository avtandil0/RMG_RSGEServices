import Vue from 'vue'
import App from './App.vue'
import router from './router'
import webApi from './webApi'
import vuetify from './plugins/vuetify';
import moment from 'moment'
import constants from './constants'

moment.locale('ge', {
  months: constants.GEO_MONTH_NAMES,
  monthsShort: constants.GEO_MONTH_SHORT_NAMES,
})

Vue.config.productionTip = false
Vue.prototype.$http = webApi
Vue.config.ignoredElements = ['rs-login']

Vue.filter('dateToDayMonthYear', date => {
  if (!date) {
    return undefined
  }
  const momentDate = moment(date, 'YYYY-MM-DDTHH:mm:ss.SSSS')

  return momentDate.isValid() ? momentDate.format('YYYY-MM-DD HH:mm') : null
})

Vue.filter("invoiceStatusesToPresentable", function(key) {
  if (!key) return "";
  return constants.INVOICE_STATUSES[key].text;
});

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
