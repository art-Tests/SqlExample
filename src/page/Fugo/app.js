// 引用組件
import pageHeader from "../../component/PageHeader.vue";
import pageForm from "../../component/PageForm.vue";

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
