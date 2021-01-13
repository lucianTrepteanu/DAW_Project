var app = new Vue({
    el: '#app',
    data: {
        username: "",
        password: "proiectDaw"
    },
    mounted() {

    },
    methods: {
        createUser() {
            this.loading = true;

            axios.post('/users', { username: this.username, password: this.password })
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }
});