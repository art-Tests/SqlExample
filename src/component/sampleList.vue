<template>
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
                <tr v-for="(item, idx) in model" :key="idx">
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
    </div>
</template>

<script>
    export default {
      props: ["model"]
    };
</script>

