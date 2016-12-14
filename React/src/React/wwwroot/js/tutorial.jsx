var data = [
  { id: 1, author: "Daniel Lo Nigro", text: "Hello ReactJS.NET World!" },
  { id: 2, author: "Pete Hunt", text: "This is one comment" },
  { id: 3, author: "Jordan Walke", text: "This is *another* comment" }
];

class CommentBox extends React.Component {
    constructor() {
        super();
        this.state = { data: [] }
        this.loadCommentsFromServer = this.loadCommentsFromServer.bind(this);
        this.commentSubmit = this.commentSubmit.bind(this);
    }
    ////Executed only once before rendering
    //componentWillMount() {
    loadCommentsFromServer() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadCommentsFromServer();
        //Set interval to run every 2second after that
        window.setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    }
    commentSubmit(comment) {
        var data = new FormData();
        data.append('author', comment.author);
        data.append('text', comment.text);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = function () {
            this.loadCommentsFromServer();
        }.bind(this);
        xhr.send(data);
    }
    render() {
        return(
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
                <CommentForm onCommentSubmit={this.commentSubmit}/>
            </div>    
        )
    }
}

class CommentList extends React.Component {
    render() {
        let dt = this.props.data;

        return(
            <div className="commentList">
                {dt.map(cl => <Comment author={cl.author} key={cl.id}>{cl.text}</Comment>)}
            </div>  
        )
    }
}

class CommentForm extends React.Component {
    constructor() {
        super();
        this.state = { author: "", text: "" }
        //this.authorChange = this.authorChange.bind(this);
    }
    authorChange(e) {
        this.setState({ author: e.target.value });
    }
    textChange(e) {
        this.setState({ text: e.target.value });
    }
    submit(e) {
        e.preventDefault();
        var author = this.state.author.trim();
        var text = this.state.text.trim();
        if (!text || !author) {
            return;
        }
        
        this.props.onCommentSubmit({ author: author, text: text });
        this.setState({ author: '', text: '' });
    }
    render() {
        return(
            <form className="commentForm" onSubmit={this.submit.bind(this)}>
                <input type="text"
                       placeholder="Your name"
                       value={this.state.author}
                       onChange={this.authorChange.bind(this)} />
                <input type="text"
                       placeholder="Say something..."
                       value={this.state.text}
                       onChange={this.textChange.bind(this)} />
                <input type="submit" value="Post"/>
            </form>
        )
    }
}

class Comment extends React.Component {
    render() {
        //To convert text into raw HTML
        //var mark = new Remarkable();
        //to call in JSX : {mark.render(this.props.children.toString())}

        return(
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                {this.props.children}
            </div>    
        )
    }
}

ReactDOM.render(<CommentBox url="/comments" submitUrl="/comments/new" pollInterval={2000}/>, document.getElementById("content"));
//ReactDOM.render(<CommentBox data={data}/>, document.getElementById("content"));