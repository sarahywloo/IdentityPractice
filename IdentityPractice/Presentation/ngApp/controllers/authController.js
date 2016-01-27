var IdentityPractice;
(function (IdentityPractice) {
    var Controllers;
    (function (Controllers) {
        var AuthController = (function () {
            //because we do not want the controller to do anything when the page is loaded
            //private $window: ng.IWindowService added to use login
            function AuthController($http, $window, $location) {
                this.$http = $http;
                this.$window = $window;
                this.$location = $location;
            }
            //set to void because we do not want the method to return anything
            AuthController.prototype.register = function (user) {
                this.$http.post('/api/account/register', user)
                    .then(function (response) {
                    console.log('New user registered!');
                })
                    .catch(function (response) {
                    console.log(response);
                });
            };
            AuthController.prototype.login = function (username, password) {
                var _this = this;
                //form url input
                var data = "grant_type=password&username=" + username + "&password=" + password;
                this.$http.post("/token", data, {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                })
                    .then(function (response) {
                    _this.$window.localStorage.setItem('token', response.data['access_token']);
                    _this.$location.path('/');
                })
                    .catch(function (response) {
                    console.log(response);
                });
            };
            AuthController.prototype.logout = function () {
                this.$window.localStorage.removeItem('token');
            };
            return AuthController;
        })();
        Controllers.AuthController = AuthController;
        angular.module('IdentityPractice').controller('authController', AuthController);
    })(Controllers = IdentityPractice.Controllers || (IdentityPractice.Controllers = {}));
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=authController.js.map