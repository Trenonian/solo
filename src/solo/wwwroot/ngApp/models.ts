namespace solo.Models {

    export class Board {
        _id: number;
        get id() {
            return this._id;
        }
        _name: string;
        get name() {
            return this._name;
        }
        _posts;
        get posts() {
            return this._posts;
        }
        addPost(newPost:Post) {
            this._posts.push(newPost);
        }
        removePost(delPost:Post) {
            this._posts = this._posts.filter((post) => { return delPost.id !== post.id });
        }
        _mods;
        get mods() {
            return this._mods;
        }
        addMod(newMod:User) {
            this._mods.push(newMod);
        }
        removeMod(delMod: User) {
            this._mods = this._mods.filter((mod) => { return mod.id !== delMod.id });
        }
        _banned;
        get banned() {
            return this._banned;
        }
        addBanned(newBanned: User) {
            this._banned.push(newBanned);
        }
        removeBanned(delBanned: User) {
            this._banned = this._banned.filter((ban) => { return ban.id !== delBanned.id });
        }
        _allowed;
        get allowed() {
            return this._allowed;
        }
        addAllowed(newAllowed: User) {
            this._allowed.push(newAllowed);
        }
        removeAllowed(delAllowed: User) {
            this._allowed = this._allowed.filter((allow) => { return allow.id !== delAllowed.id });
        }
        constructor(name: string, creator: User, ids: solo.Services.IDService) {
            this._id = ids.boardId;
            ids.boardId++;
            this._name = name;
            this._posts = [];
            this._mods = [];
            this._allowed = [];
            this._banned = [];
            this._mods.push(creator);
        }
    }

    export class Post {
        _id: number;
        get id() {
            return this._id;
        }
        _creator: User;
        get creator() {
            return this._creator;
        }
        _content: string;
        get content() {
            return this._content;
        }
        editContent(user: User, newContent: string) {
            this.edits.push({
                time: new Date(),
                old: this._content
            });
            this._content = newContent;
        }
        _created: Date;
        get created() {
            return this._created;
        }
        edits;
        _comments;
        get comments() {
            return this._comments;
        }
        addComment(newComment: Comment) {
            this._comments.push(newComment);
        }
        removeComment(delComment:Comment) {
            this._comments = this._comments.filter((comment) => { comment.id !== delComment.id } );
        }
        _score;
        get score() {
            return this._score;
        }
        hasVoted(user: User) {
            let index = -1;
            return {
                user: this._voted.find((votedUser, idx) => {
                        index = idx;
                        return user.id === votedUser.id;
                }),
                index: index
            };
        }
        _voted;
        get voted() {
            return this._voted;
        }
        upVote(user: User) {
            let oldVote = this.hasVoted(user);

            switch (oldVote.user.value) {
                case undefined:
                    this._score += 1;
                    this._voted.push({ id: oldVote.user.id, value:1});
                    break;
                case -1:
                    this.score[oldVote.index].value = 1;
                    this._score += 2;
                    break;
                case 0:
                    this.score[oldVote.index].value = 1;
                    this._score += 1;
                    break;
                case 1:
                    this.score[oldVote.index].value = 0;
                    this._score += -1;
            }
        }
        downVote(user: User) {
            let oldVote = this.hasVoted(user);

            switch (oldVote.user.value) {
                case undefined:
                    this._score += -1;
                    this._voted.push({ id: oldVote.user.id, value: -1 });
                    break;
                case -1:
                    this.score[oldVote.index].value = 0;
                    this._score += 1;
                    break;
                case 0:
                    this.score[oldVote.index].value = -1;
                    this._score += -1;
                    break;
                case 1:
                    this.score[oldVote.index].value = -1;
                    this._score += -2;
                    
            }
        }
        constructor(creator: User, ids: solo.Services.IDService) {
            this._creator = creator;
            this._id = ids.postId;
            ids.postId++;
            this._created = new Date();
            this.edits = [];
            this._comments = [];
            this.voted = [];
            this._score = 0;
        }
    }

    export class Comment {
        _id: number;
        get id() {
            return this._id;
        }
    }

    export class User {
        _id: number;
        get id() {
            return this._id;
        }
    }

    export class Admin extends User {
        
    }

}