import React, { Component } from 'react';

export default class PageTitle extends Component {

    render() {
        return (
            <div className="title">
                <div className="row">
                    <div className="column">
                        <h1>{this.props.pageName}</h1>
                    </div>
                </div>
                <div className="row">
                    <div className="column">
                        <hr className="separator" />
                    </div>
                </div>
            </div>
        );
    }
}