export default {
  props: ["sqlcmd", "title"],
  template: `
    <div>
        <h2>Search Test For SQL Command Helper <small> {{ title }} </small></h2>
        <pre>{{ sqlcmd }}</pre>
    </div>
    `
};
