<template>
    <div>
        <h2>Search Test For SQL Command Helper <small> {{ title }} </small></h2>
        <pre>{{ sqlcmd }}</pre>
    </div>
</template>
<script>
    export default {
      props: ["sqlcmd", "title"]
    };
</script>

