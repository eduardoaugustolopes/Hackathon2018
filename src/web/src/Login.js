import React, { Component } from 'react';
import Radium from 'radium';
import axios from 'axios';
import ReactDOM from 'react-dom';

import Calendar from 'react-calendar';

import Val from './middlewares/Validation';
import Config from './middlewares/Config';

import { FaSearch, FaPlus } from 'react-icons/fa';

import Modal from 'react-responsive-modal';
import App2 from './App2';

import querystring from 'query-string';

class Login extends Component {
    constructor() {
        super();
        this.state = {
            errors: [],
            nome: '',
            senha: '',
            open: false,
        };
        this.nomeChange = this.nomeChange.bind(this);
        this.senhaChange = this.senhaChange.bind(this);
    }

    onOpenModal = () => {
        this.setState({ open: true });
    };

    onCloseModal = () => {
        this.setState({ open: false });
    };

    componentWillMount = async () => {
        var token = await localStorage.getItem("@+Care:usuario");

        if (token) {
            ReactDOM.render(<App2 />, document.getElementById('root'))
        }
    }

    nomeChange(e) {
        this.setState({ nome: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'nome') });
        });
    }

    senhaChange(e) {
        this.setState({ senha: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'senha') });
        });
    }

    handleLogin = async () => {
        let self = this;
        await axios.post('http://192.168.0.135:9591/api/security/token', querystring.stringify({
            username: this.state.nome,
            password: this.state.senha,
            grant_type: 'password'
        }),
            {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            })
            .then(async function (response) {
                await localStorage.setItem("@+Care:usuario", response.data.access_token);
                ReactDOM.render(<App2 />, document.getElementById('root'));
            })
            .catch(function (e) {
                self.setState({ message: e.response.data.message })
                alert(self.state.message);
            })
    };

    render() {
        return (
            <div style={[styles.mainContainer, styles.card]}>
                <div>
                    <div style={{ alignItems: 'center', justifyContent: 'center', marginBottom: '15%' }}>
                        <img src={require('./img/+Care_Mobile.png')} style={{ height: 200, width: 250 }} />
                    </div>
                    <input
                        className="form-input input-sm"
                        type="text"
                        key="nome"
                        style={styles.input}
                        placeholder="Nome"
                        onChange={this.nomeChange}
                        value={this.state.nome}
                    />
                    <div style={styles.space2}>
                    </div>
                    <input
                        className="form-input input-sm"
                        type="text"
                        key="senha"
                        style={styles.input}
                        placeholder="Senha"
                        onChange={this.senhaChange}
                        value={this.state.senha}
                    />
                    <div style={{ backgroundColor: '#6DDFE4', marginBottom: '15%' }}>
                        <span style={{ fontSize: 20, color: '#ffffff', marginLeft: '40%' }} onClick={this.handleLogin}>Entrar</span>
                    </div>
                </div>
            </div>
        )
    }
}

const styles = {
    mainContainer: {
        backgroundColor: '#0084C1',
        marginTop: '9%',
        marginBottom: '9%',
        marginLeft: '35%',
        marginRight: '35%',
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        display: 'flex',
        flexDirection: 'column',

    },
    container: {
        height: '100%',
        width: '100%',
        flexDirection: 'row',
        display: 'flex',
        alignItems: 'flex-start'
    },
    card: {
        height: '40%',
        boxShadow: '0px 8px 16px 0px rgba(0,0,0,0.2)'
    },
    card2: {
        height: '80%',
        width: '30%',
        boxShadow: '0px 8px 16px 0px rgba(0,0,0,0.2)',
    },
    space: {
        height: '80%',
        width: '5%',
    },
    space2: {
        height: '80%',
        width: '20%',
    },
    calendar: {
        width: '100%'
    },
    input: {
        boxShadow: 'none',
        ':focus': {
            border: 'none',
            boxShadow: '0px 0px 1px 2px #023d44'
        },
        marginBottom: '8%',
        flex: 1,
        fontSize: 20,
    },
    input2: {
        boxShadow: 'none',
        ':focus': {
            border: 'none',
            boxShadow: '0px 0px 1px 2px #023d44'
        },
        paddingLeft: '5%',
        paddingRight: '5%',
        flex: 1
    },
    btnPrimary: {
        background: '#023d44',
        color: '#fff',
        border: 'solid 1px #023d44',
        boxShadow: 'none',
        ':active': {
            background: '#00a859'
        }
    },
    btn: {
        color: '#023d44',
        border: 'solid 1px #023d44',
        boxShadow: 'none',
        ':active': {
            background: '#00a859',
            color: '#fff'
        }
    },
    p: {
        whiteSpace: 'pre',
        margin: 0
    },
    inputFlex: {
        height: '100%',
        width: '100%'
    },
    space: {
        height: '80%',
        width: '5%',
    },
    space2: {
        height: '80%',
        width: '20%',
    },
};

export default Radium(Login);