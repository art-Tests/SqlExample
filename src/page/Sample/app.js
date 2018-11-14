// 引用組件
import sampleTitle from "./sampleTitle.js";
import sampleForm from "./sampleForm.js";
import sampleList from "./sampleList.js";

new Vue({
  el: "#app",
  // 註冊組件
  components: {
    "comp-page-title": sampleTitle,
    "comp-page-form": sampleForm,
    "comp-page-list": sampleList
  },
  // 組件透過prop取得data，宣告於此
  data: {
    model: [],
    condition: {},
    vm
  },
  // 頁面掛載時從 DOM 取得後端給予之Json
  mounted: function() {
    var $vm = $("#vm");
    this.vm = $vm.data("vm");
    this.model = this.vm.Data; // 若直接將vm.Data丟給component，console會錯誤
    this.condition = this.vm.Condition;
  }
});
