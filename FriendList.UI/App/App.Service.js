friendApp.factory('friendSerice', function ($http) {
    return {

        getAllFriend: function () {
            return $http.get('/friend/GetAllFriend');
        },

        addFriend: function (data) {
            return $http.post('/friend/AddFriend', data);
        },

        updateFriend: function (data) {
            return $http.put('/friend/UpdateFriend', data);

        },

        removeFriend: function (friendId) {
            return $http.delete('/friend/RemoveFriend', { params: { friendId: friendId } });

        }
    }
});