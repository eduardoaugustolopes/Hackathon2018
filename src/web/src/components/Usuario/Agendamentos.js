import React, { Component } from 'react';
import Radium from 'radium';
import axios from 'axios';
import Config from '../../middlewares/Config';
import Val from '../../middlewares/Validation';

import Calendar from 'react-calendar';

import { FaSearch, FaPlus } from 'react-icons/fa';

import Modal from 'react-responsive-modal';

class Agendamentos extends Component {
    constructor() {
        super();
        this.state = {
            errors: [],
            data: '',
            hora: '',
            medico: '',
            paciente: '',
            date: '',
            open: false,
        };
        this.dataChange = this.dataChange.bind(this);
        this.horaChange = this.horaChange.bind(this);
        this.medicoChange = this.medicoChange.bind(this);
        this.pacienteChange = this.pacienteChange.bind(this);
    }

    onOpenModal = () => {
        this.setState({ open: true });
    };

    onCloseModal = () => {
        this.setState({ open: false });
    };

    onChange = date => this.setState({ date })

    render() {
        return (
            <div style={styles.mainContainer}>
                <Modal open={this.state.open} onClose={this.onCloseModal} center>
                    <div style={styles.container}>
                        <div>
                            <label className="form-label label-sm">Data</label>
                            <input
                                className="form-input input-sm"
                                type="date"
                                key="data"
                                style={styles.input2}
                                placeholder="00/00/0000"
                                onChange={this.dataChange}
                                value={this.state.data}
                            />
                            <label className="form-label label-sm">Hora</label>
                            <input
                                className="form-input input-sm"
                                type="time"
                                key="hora"
                                style={styles.input2}
                                placeholder="15:00:00"
                                onChange={this.horaChange}
                                value={this.state.hora}
                            />
                        </div>
                        <div style={styles.space2}>
                        </div>
                        <div>
                            <label className="form-label label-sm">Médico</label>
                            <input
                                className="form-input input-sm"
                                type="text"
                                key="medico"
                                style={styles.input}
                                placeholder="Digite o CRM ou o nome do médico..."
                                onChange={this.medicoChange}
                                value={this.state.medico}
                            />
                            <label className="form-label label-sm">Paciente</label>
                            <input
                                className="form-input input-sm"
                                type="text"
                                key="paciente"
                                style={styles.input}
                                placeholder="Digite o CPF do paciente..."
                                onChange={this.pacienteChange}
                                value={this.state.paciente}
                            />
                        </div>
                    </div>
                    <div style={{ marginLeft: '25%' }}>
                        <span onClick={this.add} style={{ fontSize: 25, marginRight: '15%', color: '#12b8cc' }}>Confirmar</span>
                        <span onClick={this.onCloseModal} style={{ fontSize: 25, color: '#12b8cc' }}>Cancelar</span>
                    </div>
                </Modal>
                <div style={styles.space2}>
                </div>
                <div className="card" style={styles.card}>
                    <Calendar
                        onChange={this.onChange}
                        value={this.state.date}
                        style={styles.calendar}
                    />
                </div>
                <div style={styles.space}>
                </div>
                <div className="card" style={styles.card2}>
                    <div style={{ alignContent: 'center', marginLeft: '5%', marginRight: '5%', marginTop: '5%' }}>
                        <select style={{ paddingLeft: '28%', paddingRight: '28%' }}>
                            <option value="dr.junior">Dr. Junior</option>
                            <option value="dra.maria">Dra. Maria</option>
                            <option selected value="dr.francisco">Dr. Francisco</option>
                            <option value="dr.paulo">Dr. Paulo</option>
                        </select>
                    </div>
                    <div style={{ marginTop: '5%' }}>
                        <h3 style={{ marginLeft: '75%' }}><FaSearch size={20} /> <FaPlus size={20} onClick={this.onOpenModal} /></h3>
                    </div>
                    <div style={{ marginLeft: '5%' }}>
                        <text><span style={{ color: "#09c5f4" }}> 14:00h </span><span> Eduardo Augusto Lopes </span><br /> <span style={{ marginLeft: '20%', fontWeight: 'bold' }}> Dr. Danilo Alves </span> </text>
                    </div>
                </div>
            </div>
        )
    }

    dataChange(e) {
        this.setState({ data: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'data') });
        });
    }

    horaChange(e) {
        this.setState({ hora: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'hora') });
        });
    }

    medicoChange(e) {
        this.setState({ medico: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'medico') });
        });
    }

    pacienteChange(e) {
        this.setState({ paciente: e.target.value }, () => {
            this.setState({ errors: Val.remove(this.state.errors, 'paciente') });
        });
    }

    add = async () => {
        var dados = {
            Medico: {
                Crm: this.state.medico
            },
            Paciente: {
                Cpf: this.state.paciente
            },
            DataHoraMarcada: this.state.data + 'T' + this.state.hora,
            TempoEstimado: "00:30"
        };

        try {
            var token = await localStorage.getItem("@+Care:usuario");
            const res = await axios({
                method: 'post',
                url: Config.ApiV1 + 'Agenda/Save',
                data: JSON.stringify(dados),
                headers: {
                    "Content-Type": "application/json;charset=utf-8",
                    "Authorization": `Bearer ${token}`
                }
            });
            alert(res.data.Message)
            this.onCloseModal();
        }
        catch (err) {
            this.setState({
                errors: err.response.status == 422 ? err.response.data.errors : []
            });
        }
    }
};

const styles = {
    mainContainer: {
        flexDirection: 'row',
        display: 'flex',
        alignItems: 'flex-start'
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
        paddingLeft: '28%',
        paddingRight: '28%',
        flex: 1
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
    }
};

export default Radium(Agendamentos);