namespace IdentityPractice.Controllers {

    export class AuthController {

        public user;

        //because we do not want the controller to do anything when the page is loaded
        //private $window: ng.IWindowService added to use login
        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) { }

        //set to void because we do not want the method to return anything
        public register(user): void {

            this.$http.post('/api/account/register', user)
                .then((response) => {
                    console.log('New user registered!');
                })
                .catch((response) => {
                    console.log(response);
                });
        }

        public login(username, password): void {
            //form url input
            let data = `grant_type=password&username=${username}&password=${password}`;

            this.$http.post("/token", data, {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
                .then((response) => {
                    this.$window.localStorage.setItem('token', response.data['access_token']);
                    this.$location.path('/');
                })
                .catch((response) => {
                    console.log(response);
                }); 
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }
    }


    angular.module('IdentityPractice').controller('authController', AuthController);
}

