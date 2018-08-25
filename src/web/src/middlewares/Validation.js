const Validation = {};

Validation.invalid = (errors, field) => {
    const errs = errors.filter(x => x.field === field);
    return errs.length > 0 ? 'has-error' : '';
}

Validation.messages = (errors, field) => {
    const messages = [];
    for (let err of errors) {
        if (err.field === field) {
            messages.push(messages.length > 0 ? '\r\n' + err.message : err.message);
        }
    };
    return messages;
}

Validation.remove = (errors, field) => {
    return errors.filter(x => x.field !== field);
}

export default Validation;