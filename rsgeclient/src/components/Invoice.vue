<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="3">
        <v-layout row>
          <v-flex xs11>
            <v-select
              :items="statuses"
              v-model="searchForm.status"
              label="სტატუსი"
            ></v-select>
          </v-flex>
        </v-layout>
      </v-col>

      <v-col cols="12" sm="3">
        <v-layout row>
          <v-flex xs11>
            <v-text-field
              label="გამყიდველის დასახელება"
              v-on:keyup.enter="onEnterSearch"
              v-model="searchForm.desc"
            ></v-text-field>
          </v-flex>
        </v-layout>
      </v-col>

      <v-col cols="12" sm="3">
        <v-layout row>
          <v-flex xs11>
            <v-menu
              v-model="menu1"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="searchForm.followDateFrom"
                  label="ოპერაციის თარიღიდან"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="searchForm.followDateFrom"
                @input="menu1 = false"
                type="month"
              ></v-date-picker>
            </v-menu>
          </v-flex>
        </v-layout>
        <v-layout row></v-layout>
      </v-col>

      <v-col cols="12" sm="3">
        <v-layout row>
          <v-flex xs11>
            <v-menu
              v-model="menu2"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="searchForm.followDateTo"
                  label="ოპერაციის თარიღამდე"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="searchForm.followDateTo"
                @input="menu2 = false"
                type="month"
              ></v-date-picker>
            </v-menu>
          </v-flex>
        </v-layout>
      </v-col>
    </v-row>

    <v-btn
      @click="search"
      :loading="loadingTable"
      class="ma-2"
      outlined
      color="indigo"
    >
      <v-icon>mdi-magnify</v-icon>
      <div style="padding: 0px 0px 3px 3px">ძებნა</div>
    </v-btn>
    <!-- <v-btn class="ma-2" tile color="indigo" dark>
      <v-icon>mdi-plus-circle-outline</v-icon>
      <div style="padding: 0px 0px 3px 3px">დამატება</div>
    </v-btn>
    <v-btn class="ma-2" tile color="indigo" dark>
      <v-icon>mdi-delete</v-icon>
      <div style="padding: 0px 0px 3px 3px">გასუფთავება</div>
    </v-btn> -->
    <!-- <v-btn outlined color="secondary">
      <v-icon>mdi-file-export</v-icon>

      <div style="padding: 0px 0px 3px 3px">ექსპორტი</div>
    </v-btn> -->

    <v-data-table
      :headers="headers"
      :items="invoices"
      :loading="loadingTable"
      :items-per-page="10"
      sort-by
      class="elevation-1 mb-4"
    >
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>ანგარიშ-ფაქტურები</v-toolbar-title>
        </v-toolbar>
      </template>
      <template v-slot:body="{ items }">
        <tbody>
          <tr v-for="item in items" :key="item.objectId">
            <td>
              <v-layout>
                <v-flex>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on }">
                      <v-btn
                        v-on="on"
                        text
                        icon
                        class="table-action-button"
                        @click="openViewDialog(item)"
                      >
                        <v-icon>mdi-magnify</v-icon>
                      </v-btn>
                    </template>
                    <span>დათვალიერება</span>
                  </v-tooltip>
                </v-flex>
                <v-flex>
                  <v-tooltip bottom>
                    <template v-slot:activator="{ on }">
                      <v-btn
                        v-on="on"
                        text
                        icon
                        class="table-action-button"
                        @click="openTransactionDialog(item)"
                      >
                        <v-icon>mdi-clipboard-check</v-icon>
                      </v-btn>
                    </template>
                    <span>გატარება</span>
                  </v-tooltip>
                </v-flex>
              </v-layout>
            </td>
            <td>{{ item.STATUS | invoiceStatusesToPresentable }}</td>
            <td>{{ item.ID }}</td>
            <!-- <td>{{ item.F_NUMBER }}</td> -->
            <td>{{ item.F_SERIES }} {{ item.F_NUMBER }}</td>
            <td>{{ item.ORG_NAME }}</td>
            <td>{{ item.REG_DT | dateToDayMonthYear }}</td>
            <td>{{ item.OPERATION_DT | dateToDayMonthYear }}</td>
            <td>{{ item.TANXA }}</td>
            <td>{{ item.SA_IDENT_NO }}</td>
            <td>{{ item.VAT }}</td>
          </tr>
        </tbody>
      </template>
    </v-data-table>

    <v-dialog v-model="viewDialog.open" max-width="950" scrollable>
      <v-card>
        <v-card-title class="headline">დათვალიერება</v-card-title>
        <v-divider></v-divider>

        <v-card-text>
          <v-row align="center">
            <v-col class="d-flex" cols="12" sm="6">
              <h3>გამყიდველი</h3>
            </v-col>
            <v-col class="d-flex" cols="12" sm="6">
              <h3>მყიდველი</h3>
            </v-col>
            <v-col class="d-flex" cols="12" sm="2">
              <v-text-field
                disabled
                v-model="viewDialog.sId"
                label="საიდენტ. №"
              ></v-text-field>
            </v-col>

            <v-col class="d-flex" cols="12" sm="3">
              <v-text-field
                disabled
                v-model="viewDialog.sName"
                label="ორგანიზაციის დასახელება"
              ></v-text-field>
            </v-col>

            <v-col class="d-flex" cols="12" sm="1"></v-col>

            <v-col class="d-flex" cols="12" sm="2">
              <v-text-field
                disabled
                v-model="viewDialog.bId"
                label="საიდენტ. №"
              ></v-text-field>
            </v-col>

            <v-col class="d-flex" cols="12" sm="3">
              <v-text-field
                disabled
                label="ორგანიზაციის დასახელება"
                placeholder="სამთო"
              ></v-text-field>
            </v-col>

            <v-col class="d-flex" cols="12" sm="12">
              <v-data-table
                :loading="loadingInvoiceGoods"
                :headers="goodsHeaders"
                :items="invoiceGoods"
                sort-by
                dense
                class="elevation-1"
              >
                <template v-slot:body="{ items }">
                  <tbody>
                    <tr v-for="item in items" :key="item.id">
                      <td>{{ item.GOODS }}</td>
                      <td>{{ item.G_UNIT }}</td>
                      <td>{{ item.G_NUMBER }}</td>
                      <td>{{ item.FULL_AMOUNT }}</td>
                      <td>{{ item.VAT_TYPE }}</td>
                      <td>{{ item.DRG_AMOUNT }}</td>
                      <td>{{ item.GOODS }}</td>
                    </tr>
                  </tbody>
                </template>
              </v-data-table>
            </v-col>
          </v-row>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" text @click="onCloseView"
            >დახურვა</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog v-model="transactionDialog.open" max-width="800">
      <v-card>
        <v-card-title class="headline">გატარება</v-card-title>

        <v-card-text>
          <v-row align="center">
            <v-col class="d-flex" cols="12" sm="4">
              <v-autocomplete
                v-model="transferForm.kstpl"
                :items="kstplOptions"
                label="kstpl"
              ></v-autocomplete>
            </v-col>
            <v-col class="d-flex" cols="12" sm="4">
              <v-autocomplete
                v-model="transferForm.kstdr"
                :items="kstdrOptions"
                label="kstpdr"
              ></v-autocomplete>
            </v-col>
            <v-col class="d-flex" cols="12" sm="4">
              <v-autocomplete
                v-model="transferForm.prProject"
                :items="prProjectOptions"
                label="prProject"
              ></v-autocomplete>
            </v-col>
          </v-row>
          <v-row align="center">
            <v-col class="d-flex" cols="12" sm="4">
              <v-autocomplete
                v-model="transferForm.dagbk"
                :items="dagbkOptions"
                label="Dagbk"
              ></v-autocomplete>
            </v-col>

            <v-col class="d-flex" cols="12" sm="4">
              <v-autocomplete
                v-model="transferForm.grtbk"
                :items="grtbkOptions"
                label="Grtbk"
              ></v-autocomplete>
            </v-col>

            <v-col class="d-flex" cols="12" sm="4">
              <v-menu
                v-model="tMenu"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-model="transferForm.date"
                    label="გატარების თარიღი"
                    readonly
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker
                  v-model="transferForm.date"
                  @input="tMenu = false"
                ></v-date-picker>
              </v-menu>
            </v-col>

            <v-col class="d-flex" cols="12" sm="12">
              <v-textarea
                v-model="transferForm.comment"
                outlined
                cols="16"
                label="კომენტარი"
                rows="3"
                value
              ></v-textarea>
            </v-col>
          </v-row>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn
            color="green darken-1"
            :loading="loadingTrans"
            text
            @click="saveTransaction"
            >შენახვა</v-btn
          >

          <v-btn color="green darken-1" text @click="onCloseTransaction"
            >დახურვა</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
import constants from "../constants";
import map from "lodash/map";
import utils from "../utils";

export default {
  name: "Invoice",

  data: () => ({
    loadingTrans: false,
    loadingInvoiceGoods: false,
    dagbkList: [],
    grtbkList: [],
    kstdrList: [],
    prprojectList: [],
    kstplList: [],
    searchForm: {
      status: null,
      desc: "",
      followDateFrom: new Date(new Date().getTime() - 7 * 24 * 60 * 60 * 1000)
        .toISOString()
        .substr(0, 7),
      followDateTo: new Date(new Date().getTime() + 1 * 24 * 60 * 60 * 1000)
        .toISOString()
        .substr(0, 7),
    },
    menu1: null,
    menu2: null,
    tMenu: null,
    transferForm: {
      grtbk: null,
      dagbk: null,
      prProject: null,
      kstdr: null,
      kstpl: null,
      comment: null,
      VAT: null,
      date: new Date(new Date().getTime()).toISOString().substr(0, 10),
    },

    loadingTable: false,
    invoices: [],
    headers: [
      { text: "მოქმედებები", value: "", sortable: false },
      { text: "სტატუსი", value: "", sortable: false },
      { text: "ID", value: "", sortable: false },
      // { text: "F_NUMBER", value: "", sortable: false },
      { text: "სერია", value: "", sortable: false },
      { text: "გამყიდველი", value: "", sortable: false },
      { text: "გამოწერის თარიღი", value: "", sortable: false },
      { text: "ოპერაციის თარიღი", value: "", sortable: false },
      { text: "თანხა", value: "", sortable: false },
      { text: "სერია", value: "", sortable: false },
      { text: "დღგ-ს თანხა", value: "", sortable: false },
    ],
    invoiceGoods: [],
    goodsHeaders: [
      { text: "საქონელი / მომსახურება", value: "", sortable: false },
      { text: "ზომის ერთეული", value: "", sortable: false },
      { text: "რაოდენობა", value: "", sortable: false },
      {
        text:
          "მისაწოდებული საქონლის/გასაწევი მომსახურების საკომპენსაციო თანხა/თანხის ნაწილი (ავანსი)",
        value: "",
        sortable: false,
      },
      { text: "დაბეგვრა", value: "", sortable: false },
      { text: "დღგ", value: "", sortable: false },
      { text: "ნაშთი რაოდ. / თანხა", value: "", sortable: false },
    ],
    transactionDialog: {
      open: false,
      id: null,
      sId: null,
      sName: null,
      bId: null,
      seria: null,
      amount: null,
      invoiceNumber: null,
    },
    viewDialog: {
      open: false,
      id: null,
      sId: null,
      sName: null,
      bId: null,
    },
  }),
  async created() {
    //ї¦Її
    console.log(1111111, utils.tranformToUnicode("ї¦Її"));
    //  var test = await this.$http.get_ser_users();
    // var test1 = await this.$http.get_un_id_from_user_id();
    // console.log("test1", test1);

    // var getBuyerInvoicesR  = await this.$http.getBuyerInvoicesR();
    // this.invoices = getBuyerInvoicesR.DocumentElement.invoice_descs
    this.search();
    // var rs = await this.$http.get_un_id_from_tin();
    // console.log('rs',rs)
    let dagbkList0 = await this.$http.getDagbk();
    dagbkList0.forEach((element) => {
      element.oms250 = utils.tranformToUnicode(element.oms250);
    });
    this.dagbkList = dagbkList0;

    let grtbkList0 = await this.$http.getGrtbk();
    grtbkList0.forEach((element) => {
      element.oms250 = utils.tranformToUnicode(element.oms250);
    });
    this.grtbkList = grtbkList0;

    let kstdrList0 = await this.$http.getKstdr();
    kstdrList0.forEach((element) => {
      element.oms250 = utils.tranformToUnicode(element.oms250);
    });
    this.kstdrList = kstdrList0;

    let kstplList0 = await this.$http.getKstpl();
    kstplList0.forEach((element) => {
      element.oms250 = utils.tranformToUnicode(element.oms250);
    });
    this.kstplList = kstplList0;

    let prprojectList0 = await this.$http.getPrproject(); //description
    prprojectList0.forEach((element) => {
      element.description = utils.tranformToUnicode(element.description);
    });
    this.prprojectList = prprojectList0;
  },
  methods: {
    onEnterSearch() {
      console.log("aaaaaaa");
      this.search();
    },
    onCloseView() {
      this.viewDialog = {
        open: false,
        id: null,
      };
    },
    async openViewDialog(item) {
      console.log("item", item);
      this.invoiceGoods = [];
      this.viewDialog = {
        open: true,
        id: item.ID,
        sId: item.SA_IDENT_NO,
        sName: item.ORG_NAME,
        amount: item.TANXA,
        VAT: item.VAT,
        bId: "404908775",
      };

      this.loadingInvoiceGoods = true;

      var getInvoiceDesc = await this.$http.getInvoiceDesc(this.viewDialog.id);
      console.log("getInvoiceDesc", getInvoiceDesc);
      if (getInvoiceDesc.DocumentElement.invoices_descs.length > 1) {
        this.invoiceGoods.push(
          ...getInvoiceDesc.DocumentElement.invoices_descs
        );
      } else {
        this.invoiceGoods.push(getInvoiceDesc.DocumentElement.invoices_descs);
      }
      this.loadingInvoiceGoods = false;
    },
    async saveTransaction() {
      // console.log(
      //   "from unicode",
      //   utils.transformFromUnicode(this.transferForm.comment)
      // );
      var trans = {
        date: new Date(), //this.transferForm.date,
        dagbknr: this.transferForm.dagbk? this.transferForm.dagbk.toString() : '',
        // comment: utils.transformFromUnicode(this.transferForm.comment),
        // seller: this.transactionDialog.sId,
        // amount: parseFloat(this.transactionDialog.amount),
        // invoiceNumber: this.transactionDialog.invoiceNumber,
        // reknr: this.transferForm.grtbk,
        // kstrlCode: this.transferForm.kstpl,
        // project: this.transferForm.prProject,
        // vat: parseFloat(this.transactionDialog.VAT),
      };
      console.log(trans);
      this.loadingTrans = true;
      var postTrans = await this.$http.postTransaction(trans);
      this.loadingTrans = false;
      this.$toast(postTrans.message, {
        color: postTrans.isSuccess ? "green" : "red",
        dismissable: true,
      });

      if (postTrans.isSuccess) {
        this.transactionDialog.open = false;
      }
    },
    onCloseTransaction() {
      this.transactionDialog = {
        open: false,
        id: null,
        sId: null,
        sName: null,
        seria: null,
        invoiceNumber: null,
        amount: null,
        VAT: null,
      };
    },
    openTransactionDialog(item) {
      console.log(
        "utils.transformFromUnicode(item.F_SERIES)",
        utils.transformFromUnicode(item.F_SERIES)
      );
      this.transactionDialog = {
        open: true,
        id: item.ID,
        sId: item.SA_IDENT_NO,
        sName: item.ORG_NAME,
        seria: utils.transformFromUnicode(item.F_SERIES) + "" + item.F_NUMBER,
        invoiceNumber:
          utils.transformFromUnicode(item.F_SERIES) + " " + item.F_NUMBER,
        amount: item.TANXA,
        VAT: item.VAT,
        bId: "206322102",
      };
      this.transferForm.dagbk = "399"; // default
      console.log("this.trasferForm", this.transferForm);
    },
    async search() {
      this.loadingTable = true;
      console.log("this.searchForm", this.searchForm);
      var getBuyerInvoices = await this.$http.getBuyerInvoices(this.searchForm);
      if (
        getBuyerInvoices &&
        getBuyerInvoices.DocumentElement &&
        getBuyerInvoices.DocumentElement.invoices &&
        Array.isArray(getBuyerInvoices.DocumentElement.invoices)
      ) {
        this.invoices = getBuyerInvoices.DocumentElement.invoices;
        if (this.searchForm.status != null) {
          this.invoices = this.invoices.filter(
            (r) => r.STATUS == this.searchForm.status
          );
        }
      } else {
        this.invoices = [];
      }

      this.loadingTable = false;
    },
  },
  computed: {
    prProjectOptions() {
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(this.prprojectList, (item) => ({
          text: item.projectNr + " " + item.description,
          value: item.projectNr,
        })),
      ];
    },
    kstdrOptions() {
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(this.kstdrList, (item) => ({
          text: item.kstdrcode + " " + item.oms250,
          value: item.id,
        })),
      ];
    },
    kstplOptions() {
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(this.kstplList, (item) => ({
          text: item.kstplcode + " " + item.oms250,
          value: item.kstplcode,
        })),
      ];
    },
    grtbkOptions() {
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(this.grtbkList, (item) => ({
          text: item.reknr + " " + item.oms250,
          value: item.reknr,
        })),
      ];
    },
    dagbkOptions() {
      console.log("---------", this.dagbkList);
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(this.dagbkList, (item) => ({
          text: item.dagbknr + " " + item.oms250,
          value: item.dagbknr,
        })),
      ];
    },
    statuses() {
      return [
        { text: "- აირჩიეთ -", value: null },
        ...map(constants.INVOICE_STATUSES, (item) => ({
          text: item.text,
          value: item.value,
        })),
      ];
    },
  },
};
</script>
