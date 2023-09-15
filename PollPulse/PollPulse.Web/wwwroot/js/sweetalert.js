window.FireSweetAlert = () => {
    return new Promise((resolve) => {
        Swal.fire({
            icon: 'success',
            title: 'Registration Successful!',
            text: 'A confirmation email has been sent to your address. Please click the link inside to complete your registration.',
            confirmButtonText: 'OK',
            backdrop: 'rgba(0,0,123,0.4)',
            showClass: {
                popup: 'slow-animated animate__fadeInDown',
            },
            hideClass: {
                popup: 'slow-animated animate__fadeOutUp',
            }
        }).then(() => {
            resolve();
        });
    });
};





