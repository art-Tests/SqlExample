// 引用組件
import pageHeader from "../../component/PageHeader.js";
import pageForm from "../../component/PageForm.js";

new Vue({
  el: "#app",
  components: {
    "page-header": pageHeader,
    "page-form": pageForm
  },
  data: {
    vm
  },
  mounted: function() {
    var $vm = $("#vm");
    this.vm = $vm.data("vm");
  }
});
