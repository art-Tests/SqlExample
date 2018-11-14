export default {
    props: ["condition"],
    methods: {
        reset: function () {
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
            <label>客戶編號:</label>
            <input type="text" name="CustomerId" v-model="condition.CustomerId" /> <br />
            <label>指派日期:</label>
            <input type="text" name="AssignDateStart" v-model="condition.AssignDateStart" />
            <input type="text" name="AssignDateEnd" v-model="condition.AssignDateEnd" />
            <br />
            <label>
                Helper Type 1
                <input type="radio" name="HelperType" value="1" v-model="condition.HelperType" />
            </label>
            <input type="button" v-on:click="reset" value="cleanup" />
            <input type="submit" value="Search" />
        </form>
    </div>
  `
};