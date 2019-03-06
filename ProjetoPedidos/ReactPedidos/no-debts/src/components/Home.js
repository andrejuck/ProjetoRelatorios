import React, { Component } from 'react';
import PageTitle from './micro-components/PageTitle';
import Card from './micro-components/Card';

export default class Home extends Component {

    render() {
        const arrayList = {
             "data": [
                { name: 'Bancos' }, 
                { name: 'Formas de Pagamento' }, 
                { name: 'Plano de Contas' }
            ] 
        }
        return (
            <div className="ui container">
                <PageTitle pageName="Visão Geral" />
                <div className="row">
                    <div className="four wide column">
                        <Card
                            header="Cadastros"
                            body="Conteúdo do card Simples"
                            footer="Rodapé card Simples"
                            list={arrayList}
                        />
                    </div>
                    <div className="four wide column">
                        <Card
                            header="Card Simples"
                            body="Conteúdo do card Simples"
                            footer="Rodapé card Simples"
                        />
                    </div>
                    <div className="four wide column">
                        <div className="card">
                            <div className="card-header">
                                Botão cheio
                            </div>
                            <div className="card-body">
                                Lorem ipsum egestas quisque vulputate mollis curabitur dapibus etiam ac class donec
                                    </div>
                            <div className="card-footer full">
                                <button className="btn primary">
                                    <i className="fa fa-pencil"></i>
                                    Botão
                                </button>
                            </div>
                        </div>
                    </div>

                </div>
                <div className="row">
                    <div className="sixteen wide column">
                        <div className="accordion">
                            <div className="item">
                                <div className="header">
                                    <h3>Accordion</h3>
                                    <i className="fa fa-angle-down"> </i>
                                </div>
                                <div className="accordion-content">
                                    <div className="paragraph">
                                        Lorem ipsum egestas quisque vulputate mollis curabitur dapibus etiam ac class donec                                        
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
const button = (
    <button className="btn primary">Teste</button>
)