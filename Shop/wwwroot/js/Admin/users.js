var app = new Vue({
    el: '#app',
    data: {
        username: "",
        password: "bullshit"
    },
    mounted() {

    },
    methods: {
        createUser() {
            this.loading = true;

            axios.post('/users', { username: this.username, password: 'totihandicapatii'})
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }
});