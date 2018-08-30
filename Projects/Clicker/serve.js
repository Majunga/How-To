const express = require('express')

const app = express()

app.get('/', (req, res) => {
    var count = app.locals.count || 0
    app.locals.count = count + 1
    res.send("Current number of hits: " + app.locals.count)
})
app.get('/test', (req, res) => {
    res.send("Current number of hits: " + app.locals.count)
})
app.listen(3000, () => console.log('Listening on port 3000!'))