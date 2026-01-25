function markRowAsDone(itemId) {
  
    var rowElement = document.getElementById('row-' + itemId);

    if (rowElement) {
        rowElement.classList.toggle('row-done-effect');
    }
}

function confirmDelete() {
    var agreement = confirm("Are you sure you want to delete this?");
    return agreement;
}