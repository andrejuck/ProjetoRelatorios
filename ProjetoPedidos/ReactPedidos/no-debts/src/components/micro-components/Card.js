import React, { Component } from 'react';


class Card extends Component {

    render() {
        return (
            <div className="card">
                <div className="card-header">
                    {this.props.header}
                </div>
                <div className="card-body">
                    {/* <List listItens={this.props.list} /> */}
                    {this.props.body}
                </div>
                <div className="card-footer">
                    {this.props.footer}
                </div>
            </div>
        );
    }
}

export default Card 