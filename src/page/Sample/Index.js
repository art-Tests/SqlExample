Vue.component("comp-page-list", {
  props: ["model"],
  template: `
      <div>
        總筆數：{{ model.length }}
        <table class="table">
            <thead>
                <tr>
                    <th>#</th>
                    <th>OrderId</th>
                    <th>CustomerID</th>
                    <th>EmployeeID</th>
                    <th>OrderDate</th>
                    <th>ShipVia</th>
                    <th>Freight</th>
                    <th>ShipName</th>
                    <th>ShipAddress</th>
                    <th>ShipCity</th>
                    <th>ShipCountry</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, idx) in model">
                    <td>{{ idx+1 }}</td>
                    <td>{{ item.OrderID }}</td>
                    <td>{{ item.CustomerID }}</td>
                    <td>{{ item.EmployeeID }}</td>
                    <td>{{ item.OrderDate }}</td>
                    <td>{{ item.ShipVia }}</td>
                    <td>{{ item.Freight }}</td>
                    <td>{{ item.ShipName }}</td>
                    <td>{{ item.ShipAddress }}</td>
                    <td>{{ item.ShipCity }}</td>
                    <td>{{ item.ShipCountry }}</td>
                </tr>
            </tbody>
        </table>
    </div>`
});
Vue.component("comp-page-title", {
  props: ["sqlcmd", "helper"],
  template: `
    <div>
        <h2>Search Test For SQL Command Helper <small> {{ helper }} </small></h2>
        <pre>{{ sqlcmd }}</pre>
    </div>
    `
});

Vue.component("comp-page-form", {
  props: ["condition"],
  methods: {
    reset: function() {
      var $form = $("#frm");
      $form
        .find(":input")
        .not(":button, :submit, :reset, :hidden, :checkbox, :radio")
        .val("");
      $form.find(":checkbox, :radio").prop("checked", false);
    }
  },
  template: `
    <div>
        <form id="frm" method="post">
            <label>EmployeeId</label>
            <input type="text" name="EmployeeId" v-model="condition.EmployeeId" /> <br />
            <label>OrderDate</label>
            <input type="text" name="OrderDateStart" v-model="condition.OrderDateStart" />
            <input type="text" name="OrderDateEnd" v-model="condition.OrderDateEnd" />
            <br />
            <label>ShipCity</label>
            <input type="text" name="ShipCity" v-model="condition.ShipCity" />
            <br />
            <label>
                Helper Type 1
                <input type="radio" name="HelperType" value="OrderSqlHelper" v-model="condition.HelperType" />
            </label>
            <label>
                Helper Type 2
                <input type="radio" name="HelperType" value="OrderSqlHelper2" v-model="condition.HelperType" />
            </label>
            <input type="button" v-on:click="reset" value="cleanup" />
            <input type="submit" value="Search" />
        </form>
    </div>
  `
});

new Vue({
  el: "#app",
  data: {
    model: [],
    condition: {},
    vm
  },

  mounted: function() {
    var $vm = $("#vm");
    this.vm = $vm.data("vm");
    this.model = this.vm.Data; // 若直接將vm.Data丟給component，console會錯誤
    this.condition = this.vm.Condition;
  }
});
