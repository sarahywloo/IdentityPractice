﻿namespace IdentityPractice.Controllers {
    export class FriendsController {

        public friends;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/friends')
                .then((response) => {
                    this.friends = response.data;
                });
        }

        //public FindFriends() {
        //}
    }
}