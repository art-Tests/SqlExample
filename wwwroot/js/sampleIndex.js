Vue.component("comp-page-list", {
  props: ["model"],
  template: "#tmpl-sql-list"
});
Vue.component("comp-page-title", {
  props: ["sqlcmd", "helper"],
  template: "#tmpl-sql-title"
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
  template: "#tmpl-sql-form"
});

new Vue({
  el: "#app",
  data: {
    model: [],
    helper: "",
    condition: {},
    sqlcmd: ""
  },
  mounted: function() {
    this.model = $("#data").data("model");
    this.helper = $("#data").data("helper");
    this.condition = $("#data").data("condition");
    this.sqlcmd = $("#data").data("sql");
  }
});
