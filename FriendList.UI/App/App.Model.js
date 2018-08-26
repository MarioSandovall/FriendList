var friendApp = angular.module('friendApp', [])
    .controller('friendController', function ($scope, friendSerice) {
        $scope.friends = [];

        var getAllFriends = function () {
            friendSerice.getAllFriend().then(function (result) {
                $scope.friends = result.data;
            }, function (result) {
                alert("internal Error " + result.statusText);
                console.log(result);
            });
        }

        var clearValues = function() {
            $scope.data = {
                Name: undefined,
                LastName: undefined
            }
        }

        $scope.addFriend = function (data) {
            friendSerice.addFriend(data).then(function (result) {
                getAllFriends();
                clearValues();
            }, function (result) {
                alert("internal Error " + result.statusText );
                console.log(result);
            });
        };


        $scope.updateFriend = function (data) {
            friendSerice.updateFriend(data).then(function (result) {
                getAllFriends();
            }, function (result) {
                alert("internal Error " + result.statusText);
                console.log(result);
            });
        };

        $scope.removeFriend = function (friendId) {
            friendSerice.removeFriend(friendId).then(function (result) {
                getAllFriends();
            }, function (result) {
                alert("internal Error " + result.statusText);
                console.log(result);
            });
        };

        clearValues();
        getAllFriends();
    });