export class BlogCommentCreate {
    constructor(
        public blogCommentId: number,
        public blogId: number,
        public publiccontent: string,
        public parentBlogCommentId?: number
    ) {}
}