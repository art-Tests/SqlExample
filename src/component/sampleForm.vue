<template>
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
                <input type="radio" name="HelperType" value="1" v-model="condition.HelperType" />
            </label>
            <label>
                Helper Type 2
                <input type="radio" name="HelperType" value="2" v-model="condition.HelperType" />
            </label>
            <input type="button" v-on:click="reset" value="cleanup" />
            <input type="submit" value="Search" />
        </form>
    </div>
</template>

<script>
    export default {
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
      }
    };
</script>