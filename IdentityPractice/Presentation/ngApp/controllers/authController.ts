namespace IdentityPractice.Controllers {

    export class AuthController {

        public user;

        //because we do not want the controller to do anything when the page is loaded
        constructor(private $http: ng.IHttpService) { }

        //set to void because we do not want the method to return anything
        public register(user): void {

            this.$http.post('/api/account/register', user)
                .then((response) => {
                    console.log('New user registered!');
                })
                .catch((response) => {
                    console.log(response);
                })
        }
    }
}