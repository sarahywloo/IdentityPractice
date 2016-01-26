﻿namespace IdentityPractice.Controllers {
    export class NewsFeedController {
        
        //controller only needs one variable
        public posts;

        //when you want to view it immediately, it needs to be done in the constructor
        constructor(private $http: ng.IHttpService) {
            $http.get('/api/posts') //news feed posts
                .then((response) => {
                    this.posts = response.data; //assigning response.data to posts
                });
        }
    }
}