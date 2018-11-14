export default {
  props: ["sqlcmd", "helper"],
  template: `
    <div>
        <h2>Search Test For SQL Command Helper <small> {{ helper }} </small></h2>
        <pre>{{ sqlcmd }}</pre>
    </div>
    `
};
