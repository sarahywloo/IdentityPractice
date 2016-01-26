var IdentityPractice;
(function (IdentityPractice) {
    var Controllers;
    (function (Controllers) {
        var ProfileFeedController = (function () {
            function ProfileFeedController($http, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                $http.get("/api/posts/" + $routeParams.username)
                    .then(function (response) {
                    _this.posts = response.data;
                });
            }
            return ProfileFeedController;
        })();
        Controllers.ProfileFeedController = ProfileFeedController;
    })(Controllers = IdentityPractice.Controllers || (IdentityPractice.Controllers = {}));
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=profileFeedController.js.map