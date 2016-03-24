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

    export class ScoreService {
        _score: number;
        get score() {
            return this._score;
        }
        ChangeScore(delta) {
            this._score += delta;
        }
        _postScore: number;
        get postScore() {
            return this._postScore;
        }
        ChangePostScore(delta) {
            this._postScore += delta;
        }
        _commentScore: number;
        get commentScore() {
            return this._commentScore;
        }
        ChangeCommentScore(delta) {
            this._commentScore += delta;
        }
        constructor() {
            this._score = 0;
            this._postScore = 0;
            this._commentScore = 0;
        }
    }
    angular.module('solo').service('scoreService', ScoreService);

    export class BoardService {
        boards: solo.Models.Board[];
        constructor() {
            this.boards = [];
        }
    }
    angular.module('solo').service('boardService', BoardService);


    export class TestService {
        boards;
        
    }
    angular.module('solo').service('testService', TestService);
}
