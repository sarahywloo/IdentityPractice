var IdentityPractice;
(function (IdentityPractice) {
    var Controllers;
    (function (Controllers) {
        var NewsFeedController = (function () {
            //when you want to view it immediately, it needs to be done in the constructor
            function NewsFeedController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('/api/posts') //news feed posts
                    .then(function (response) {
                    _this.posts = response.data; //assigning response.data to posts
                });
            }
            return NewsFeedController;
        })();
        Controllers.NewsFeedController = NewsFeedController;
    })(Controllers = IdentityPractice.Controllers || (IdentityPractice.Controllers = {}));
})(IdentityPractice || (IdentityPractice = {}));
//# sourceMappingURL=newsFeedController.js.map