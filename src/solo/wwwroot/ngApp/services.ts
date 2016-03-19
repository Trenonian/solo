namespace solo.Services {
    export class IDService {
        _boardId: number;
        get boardId() {
            return this._boardId;
        }
        _postId: number;
        get postId() {
            return this._postId;
        }
        _commentId: number;
        get commentId() {
            return this._commentId;
        }
        _userId: number;
        get userId() {
            return this._userId;
        }
        constructor() {
            this._boardId = 0;
            this._postId = 0;
            this._commentId = 0;
            this._userId = 0;
        }
    }
    angular.module('solo').service('idService', IDService);
}
