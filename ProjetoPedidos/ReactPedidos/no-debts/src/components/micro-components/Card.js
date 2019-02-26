import React, { Component } from 'react';

class Card extends Component {
    render() {
        return (
            <div className="card">
                {this.props.children}
            </div>
        );
    }
}

class Header extends Component {
    render() {
        return (
            <div className="card-header">
                {this.props.header}
            </div>
        );
    }
}


class Body extends Component {
   
    render() {
        return (
            <div className="card-body">
                {this.props.body}
            </div>
        );
    }
}

class Footer extends Component {
    render() {
        return (
            <div className="card-footer">
                {this.props.footer}
            </div>
        );
    }
}

export default {Header, Body, Footer}
export {Card}