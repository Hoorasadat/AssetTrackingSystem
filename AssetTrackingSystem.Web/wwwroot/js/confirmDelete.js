function confirmDelete(id, isDeleteConfirmed) {
    let deleteConfirmSpan_Id = "deleteConfirmSpan_" + id;
    let deleteButtonSpan_Id = "deleteButtonSpan_" + id;

    if (isDeleteConfirmed) {
        $("#" + deleteConfirmSpan_Id).show();
        $("#" + deleteButtonSpan_Id).hide();
    } else {
        $("#" + deleteConfirmSpan_Id).hide();
        $("#" + deleteButtonSpan_Id).show();
    }
}