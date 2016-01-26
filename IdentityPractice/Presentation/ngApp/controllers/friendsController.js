var IdentityPractice;
(function (IdentityPractice) {
    var Controllers;
    (function (Controllers) {
        var FriendsController = (function () {
            function FriendsController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('/api/friends')
                    .then(function (response) {
                    _this.friends = response.data;
                });
            }
            return FriendsController;
        })();
        Controllers.FriendsController = FriendsController;
    })(Controllers = IdentityPractice.Controllers || (IdentityPractice.Controllers = {}));
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=friendsController.js.map