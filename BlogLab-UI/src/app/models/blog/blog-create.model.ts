export class BlogCreate {
    constructor(
        public blogId: number,
        public title: string,
        public publiccontent: string,
        public photoId?: number
    ) {}
}