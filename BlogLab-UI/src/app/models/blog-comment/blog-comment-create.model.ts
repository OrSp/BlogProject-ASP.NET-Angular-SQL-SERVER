export class BlogCommentCreate {
    constructor(
        blogCommentId: number,
        blogId: number,
        content: string,
        parentBlogCommentId?: number
    ) {}
}