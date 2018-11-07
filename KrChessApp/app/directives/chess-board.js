'use strict';

angular.module('KrChessApp')

// NOTE: add dependency if needed.
.directive('chessBoard', [
    function() {
        return {
            restrict: 'E',
            templateUrl: 'app/directives/chess-board.html',
            scope: {}, // TODO: add implementation - isolated scope definition.
            link: function(scope, element) { // TODO: add implementation.

            }
        }
    }]
);
