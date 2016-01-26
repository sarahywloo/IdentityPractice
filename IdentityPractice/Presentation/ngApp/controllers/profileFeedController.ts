namespace IdentityPractice.Controllers {
    export class ProfileFeedController {

        public posts;

        constructor(private $http: ng.IHttpService, private $routeParams) {

            $http.get(`/api/posts/${$routeParams.username}`)
                .then((response) => {
                    this.posts = response.data;
                });
        }
    }
}