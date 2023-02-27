export function closeModal(modalId) {
    const noteDialogElement = document.getElementById(modalId);
    const noteDialog = bootstrap.Modal.getInstance(noteDialogElement);

    noteDialog.hide();
}
