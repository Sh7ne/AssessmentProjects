'use strict';

angular.module('KrChessApp')

// NOTE: add dependency if needed.
// TODO: add implementation.
.service('Api', [
    function(GET_DIMENSIONS_ENDPOINT) {

        // TODO: Implement this function.
        // function can return a promise so callback can be added.
        // GET_DIMENSIONS_ENDPOINT is the server endpoint which dimension can be obtained
        // No request parameters are necessary.
        // Example Response: {row: 12, column: 8}
        this.getDimensions = function() {
            

        };

        return {
            getDimensions : this.getDimensions
        };
    }]
);
