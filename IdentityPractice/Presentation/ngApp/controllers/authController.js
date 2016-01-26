var IdentityPractice;
(function (IdentityPractice) {
    var Controllers;
    (function (Controllers) {
        var AuthController = (function () {
            //because we do not want the controller to do anything when the page is loaded
            function AuthController($http) {
                this.$http = $http;
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
            return AuthController;
        })();
        Controllers.AuthController = AuthController;
    })(Controllers = IdentityPractice.Controllers || (IdentityPractice.Controllers = {}));
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=authController.js.map