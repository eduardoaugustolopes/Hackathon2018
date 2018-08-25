using Hackathon.Domain.Enums;
using System;

namespace Hackathon.Domain.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        private Clinica _clinica = new Clinica();
        public Clinica Clinica
        {
            get { return _clinica ?? new Clinica(); }
            set { _clinica = value; }
        }

        private Medico _medico = new Medico();
        public Medico Medico
        {
            get { return _medico ?? new Medico(); }
            set { _medico = value; }
        }

        private Paciente _paciente = new Paciente();
        public Paciente Paciente
        {
            get { return _paciente ?? new Paciente(); }
            set { _paciente = value; }
        }

        public DateTime DataHoraMarcada { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraConcluido { get; set; }
        public string TempoEstimado { get; set; }
        public StatusEnum Status { get; set; }
    }
}
